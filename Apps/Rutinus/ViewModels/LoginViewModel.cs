using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Global;
using Rutinus.Models;
using Rutinus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.ViewModels
{
    
    public partial class LoginViewModel : ObservableObject
    {
        private UserService _service;

        [ObservableProperty]
        public string loginId = string.Empty;
        [ObservableProperty]
        public string loginPwd = string.Empty;

        public IAsyncRelayCommand LoginCommand  { get; }
        public IAsyncRelayCommand SignUpCommand { get; }
        public LoginViewModel()
        {
            InitVariables();
            LoginCommand = new AsyncRelayCommand(OnLoginAsync);
            SignUpCommand = new AsyncRelayCommand(OnSignUpAsync);
        }

        private void InitVariables()
        {
            _service = new UserService();
            
        }

        private void InitLoad()
        { 
            // 페이지 로드시 호출되는 것 커스텀
        }

        private async Task OnLoginAsync()
        {
            // id, pwd 입력 검증
            if (string.IsNullOrEmpty(LoginId))
            {
                await App.Current.MainPage.DisplayAlert("주의", "아이디를 입력하세요.", "확인");
                return;
            }

            if (string.IsNullOrEmpty(LoginPwd))
            {
                await App.Current.MainPage.DisplayAlert("주의", "아이디를 입력하세요.", "확인");
                return;
            }

            // id, pwd 조회
            string encrytedPwd= SHA512Helper.EncryptSHA512(LoginPwd);
            
            ApiResponse<UserModel> response = await _service.GetUserUseIdPwd(LoginId, encrytedPwd);
            if (response.Data != null)
            {

                //await App.Current.MainPage.DisplayAlert("성공", "계정있음", "확인");
                AppLoginUserInfo info = new AppLoginUserInfo();
                info.LoginUserId = response.Data.UserId;
                info.LoginUserNm = response.Data.UserNm;
                info.LoginUserEmail = response.Data.UserEmail;
                ((App)Application.Current).CurrentUser = info;

                await Shell.Current.GoToAsync("///MainPage");
                return;
            }
            else
            {
                // ((App)Application.Current).Logout(); 로그아웃
                await App.Current.MainPage.DisplayAlert("실패", "아이디 비밀번호가 틀렸습니다.", "확인");
                return;
            }

        }

        private async Task OnSignUpAsync()
        {
            // 회원가입 홈페이지 이동
        }


    }
}
