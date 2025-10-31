using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RutinusApi.Repositories;

namespace RutinusApi.Pages
{
    /// <summary>
    /// ActivateModel : 계정 활성화
    /// </summary>
    public class ActivateModel : PageModel
    {
        // ASP.NET Core Razor 에서
        // Activate 라는 Url 로 
        // Activate 라는 클래스가 생성되고 Page 가 Load 될 수 있는 이유는

           // RutinusApi 하위의 Pages 폴더 하위에 Activate 라는 .cshtml 파일이 존재 하고
           // Program.cs 의 builder.services에 AddRazorPages();
           //                                  MapRazorPages(); 
           // 되었기 때문이다.

        // 이는 URL 을 바인딩할때 https://host/Activate 라는 URL 이 Pages 하위의 Activate.cshtml.cs 라는 것과 매치되며
        // ActivateModel(UserRepository repo) 생성자에 파라미터로 선언된 Repository 클래스가 Program.cs 에서
        // AddScoped(); 되어있기 때문에 자동으로 핸들러가 
        // ActivateModel 의 Instance 를 생성하면서 UserRepository 를 주입하게 된다.

        // 다른 Api Controller 도 마찬가지로 의존성이 주입될 때 
        // AddScoped(); 로 추가된 Repository 인스턴스들이 Web App 이 실행됨과 더불어
        // 어느곳에 주입되어 사용될지를 Application 이 미리 알고있기 때문에 가능하다.

        private readonly UserRepository _repo;

        public ActivateModel(UserRepository repo)
        {
            _repo = repo;
        }

        [BindProperty(SupportsGet = true)]
        public string? Token { get; set; }

        public bool IsSuccess { get; set; }
        public string resultMessage { get; set; }

        public async Task OnGetAsync()
        {
            /* 사용자 정보를 조회한다. */
            var entity = _repo.GetDuplicateUser(Token);
            string ResultMessage = "";
            bool isSuccess = false;

            if (entity == null)
            {
                ResultMessage = "고객정보가 없습니다.";
                isSuccess = false;
            }
            else
            {
                /* 사용자 회원가입 시도 일자를 조회하여 유효기간을 판단한다. */
                if (entity.TrialDt != null)
                {

                    TimeSpan timeDiff = (TimeSpan)(DateTime.Now - entity.TrialDt);
                    double totalMinute = timeDiff.TotalMinutes;
                    double totalSecond = timeDiff.TotalSeconds;

                    if (totalSecond > 30)
                    {
                        ResultMessage = "유효기간이 초과되었습니다.";
                        isSuccess = false;
                    }
                    else
                    {
                        /* 활성화를 시도한다. */
                        int result = await _repo.ActivateUserAsync(Token);

                        if (result > 0)
                        {
                            ResultMessage = "고객정보가 활성화되었습니다.";
                            isSuccess = true;
                        }
                        else
                        {
                            ResultMessage = "고객정보가 활성화되지 않았습니다.";
                            isSuccess = false;
                        }
                    }
                }
                else
                {
                    ResultMessage = "회원가입 시도가 되지 않았습니다.";
                    isSuccess = false;
                }
            }
            IsSuccess = isSuccess;
            resultMessage = ResultMessage;
        }


    }
}
