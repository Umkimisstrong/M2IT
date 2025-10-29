using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Rutinus.Global;
using Rutinus.Models;
using Rutinus.Services;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rutinus.ViewModels
{
    
    /// <summary>
    /// SignUpViewModel : SignUp 에서 사용하는 ViewModel
    /// </summary>
    public partial class SignUpViewModel : ObservableObject
    {
        #region Init

        private UserService _service;

        [ObservableProperty]
        public string loginId = string.Empty;
        [ObservableProperty]
        public string loginPwd = string.Empty;
        [ObservableProperty]
        public string loginNm = string.Empty;
        [ObservableProperty]
        public string loginPwdCheck = string.Empty;
        [ObservableProperty]
        public string loginEmail = string.Empty;
        [ObservableProperty]
        public string duplicateMessage = "사용 가능합니다.";
        [ObservableProperty]
        public Color duplicateLabelColor = Color.FromArgb("#ffffff");


        /* 중복체크 */
        private bool isDuplicateCheck = false;

        /* 회원가입 */
        public IAsyncRelayCommand SignUpCommand { get; }
        /* 중복체크 */
        public IAsyncRelayCommand DuplicateCommand { get; }
        /* 화면에 특정 요소 Focus 이벤트 전달 */
        public event Action<string> FocusRequested;

        /// <summary>
        /// RequestFocus : Focus 이벤트 실행
        /// </summary>
        /// <param name="focusName"></param>
        void RequestFocus(string focusName)
        {
            FocusRequested?.Invoke(focusName);
        }

        public SignUpViewModel()
        {
            InitVariables();
            SignUpCommand = new AsyncRelayCommand(OnSignUpAsync);
            DuplicateCommand = new AsyncRelayCommand(OnDuplicateAsync);
        }

        private void InitVariables()
        {
            _service = new UserService();
        }

        private void InitLoad()
        {
            // 페이지 로드시 호출되는 것 커스텀
        }

        #endregion



        #region Command
        /// <summary>
        /// OnSignUpAsync : 회원가입 진행
        /// </summary>
        /// <returns></returns>
        private async Task OnSignUpAsync()
        {
            // id, pwd 입력 검증
            if (string.IsNullOrEmpty(LoginId))
            {
                await App.Current.MainPage.DisplayAlert("주의", "아이디를 입력하세요.", "확인");
                RequestFocus("loginId");
                return;
            }

            if (string.IsNullOrEmpty(LoginPwd))
            {
                await App.Current.MainPage.DisplayAlert("주의", "비밀번호를 입력하세요.", "확인");
                RequestFocus("loginPwd");
                return;
            }

            if (string.IsNullOrEmpty(LoginPwdCheck))
            {
                await App.Current.MainPage.DisplayAlert("주의", "비밀번호 확인을 입력하세요.", "확인");
                RequestFocus("loginPwdCheck");
                return;
            }

            if (string.IsNullOrEmpty(LoginNm))
            {
                await App.Current.MainPage.DisplayAlert("주의", "이름을 입력하세요.", "확인");
                RequestFocus("loginNm");
                return;
            }

            if (string.IsNullOrEmpty(LoginEmail))
            {
                await App.Current.MainPage.DisplayAlert("주의", "이메일을 입력하세요.", "확인");
                RequestFocus("loginEmail");
                return;
            }

            if (!isDuplicateCheck)
            {
                await App.Current.MainPage.DisplayAlert("주의", "ID 중복확인이 필요합니다.", "확인");
                RequestFocus("loginId");
                return;
            }

            //await SendEmailAsync(LoginEmail, LoginNm);
            // pwd 조회 암호화
            string encrytedPwd = SHA512Helper.EncryptSHA512(LoginPwd);

            UserModel userModel = new UserModel()
            {
                UserId = LoginId,
                UserPwd = encrytedPwd,
                UserNm = LoginNm,
                UserEmail = LoginEmail,
                CreatedAt = DateTime.Now,
                CreatedBy = LoginId
            };
            ApiResponse<UserModel> response = await _service.InsertUser(userModel);
            if (response.Success)
            {
                await App.Current.MainPage.DisplayAlert("성공", "회원가입되었습니다. 메인페이지로 이동합니다.", "확인");
                AppLoginUserInfo info = new AppLoginUserInfo();
                info.LoginUserId = LoginId;
                info.LoginUserNm = LoginNm;
                info.LoginUserEmail = LoginEmail;
                ((App)Application.Current).CurrentUser = info;
                await SendEmailAsync(info.LoginUserNm, info.LoginUserEmail);
                await Shell.Current.GoToAsync("//MainPage");
                return;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("실패", "회원가입에 실패하였습니다.", "확인");
                return;
            }
        }

        public async Task SendEmailAsync(string toNm, string toMail)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("appsettings.json");
                GlobalSystemContainer ContainerObj = await JsonSerializer.DeserializeAsync<GlobalSystemContainer>(stream);
                GlobalSystemSettings Settings = ContainerObj.GlobalSystemSettings;
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Settings.SystemName, Settings.SystemMail));
                message.To.Add(new MailboxAddress(toNm, toMail));
                message.Subject = "MAUI 앱에서 보낸 메일";

                message.Body = new TextPart("plain")
                {
                    Text = "안녕하세요, 회원가입 인증 메일 입니다. (test)"
                };

                using var client = new MailKit.Net.Smtp.SmtpClient();
                await client.ConnectAsync(Settings.SystemHost, Settings.SystemPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(Settings.SystemMail, Settings.SystemPwd);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("오류", ex.Message, "확인");
            }
            finally 
            {
            
            }
        }

        /// <summary>
        /// OnDuplicateAsync : ID 중복여부 확인
        /// </summary>
        /// <returns></returns>
        private async Task OnDuplicateAsync()
        {
            if (string.IsNullOrEmpty(LoginId))
            {
                await App.Current.MainPage.DisplayAlert("주의", "아이디를 입력하세요.", "확인");

                return;
            }

            // 버튼 클릭 시 포커스 유지
            RequestFocus("loginId");
            ApiResponse<UserModel> response = await _service.GetDuplicateUser(LoginId);
            // 메인 스레드에서 UI 갱신
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (response.Data != null)
                {
                    ToggleDuplicateId("DUPLICATE");
                }
                else
                {
                    ToggleDuplicateId("NOTDUPLICATE");
                }
            });
            /*
            if (response.Data != null)
            {
                ToggleDuplicateId("DUPLICATE");
            }
            else
            {
                ToggleDuplicateId("NOTDUPLICATE");
            }
            */
        }
        #endregion

        #region Method
        /// <summary>
        /// ResetFields : 필드 비우기(외부에서 실행)
        /// </summary>
        public void ResetFields()
        {
            LoginId = string.Empty;
            LoginPwd = string.Empty;
            LoginPwdCheck = string.Empty;
            LoginEmail = string.Empty;
            LoginNm = string.Empty;

            ToggleDuplicateId("DEFAULT");

        }

        /// <summary>
        /// ToggleDuplicateId : 중복체크 후 이벤트 확인
        /// </summary>
        /// <param name="isDuplicate"></param>
        private void ToggleDuplicateId(string isDuplicate)
        {
            if (isDuplicate.Equals("DUPLICATE"))
            {
                DuplicateMessage = "사용 불가합니다.";
                DuplicateLabelColor = Color.FromArgb("#b05da5"); // 분홍색
                isDuplicateCheck = false;
            }
            else if (isDuplicate.Equals("NOTDUPLICATE"))
            {
                DuplicateMessage = "사용 가능합니다.";
                DuplicateLabelColor = Color.FromArgb("#0baf4d"); // 녹색
                isDuplicateCheck = true;
                RequestFocus("loginPwd");
            }
            else
            {
                DuplicateMessage = "사용 가능합니다.";
                DuplicateLabelColor = Color.FromArgb("#FFFFFF"); // 흰색
                isDuplicateCheck = false;
            }
        }
        #endregion


    }
}
