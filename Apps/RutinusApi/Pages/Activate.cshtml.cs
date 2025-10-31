using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RutinusApi.Repositories;

namespace RutinusApi.Pages
{
    /// <summary>
    /// ActivateModel : ���� Ȱ��ȭ
    /// </summary>
    public class ActivateModel : PageModel
    {
        // ASP.NET Core Razor ����
        // Activate ��� Url �� 
        // Activate ��� Ŭ������ �����ǰ� Page �� Load �� �� �ִ� ������

           // RutinusApi ������ Pages ���� ������ Activate ��� .cshtml ������ ���� �ϰ�
           // Program.cs �� builder.services�� AddRazorPages();
           //                                  MapRazorPages(); 
           // �Ǿ��� �����̴�.

        // �̴� URL �� ���ε��Ҷ� https://host/Activate ��� URL �� Pages ������ Activate.cshtml.cs ��� �Ͱ� ��ġ�Ǹ�
        // ActivateModel(UserRepository repo) �����ڿ� �Ķ���ͷ� ����� Repository Ŭ������ Program.cs ����
        // AddScoped(); �Ǿ��ֱ� ������ �ڵ����� �ڵ鷯�� 
        // ActivateModel �� Instance �� �����ϸ鼭 UserRepository �� �����ϰ� �ȴ�.

        // �ٸ� Api Controller �� ���������� �������� ���Ե� �� 
        // AddScoped(); �� �߰��� Repository �ν��Ͻ����� Web App �� ����ʰ� ���Ҿ�
        // ������� ���ԵǾ� �������� Application �� �̸� �˰��ֱ� ������ �����ϴ�.

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
            /* ����� ������ ��ȸ�Ѵ�. */
            var entity = _repo.GetDuplicateUser(Token);
            string ResultMessage = "";
            bool isSuccess = false;

            if (entity == null)
            {
                ResultMessage = "�������� �����ϴ�.";
                isSuccess = false;
            }
            else
            {
                /* ����� ȸ������ �õ� ���ڸ� ��ȸ�Ͽ� ��ȿ�Ⱓ�� �Ǵ��Ѵ�. */
                if (entity.TrialDt != null)
                {

                    TimeSpan timeDiff = (TimeSpan)(DateTime.Now - entity.TrialDt);
                    double totalMinute = timeDiff.TotalMinutes;
                    double totalSecond = timeDiff.TotalSeconds;

                    if (totalSecond > 30)
                    {
                        ResultMessage = "��ȿ�Ⱓ�� �ʰ��Ǿ����ϴ�.";
                        isSuccess = false;
                    }
                    else
                    {
                        /* Ȱ��ȭ�� �õ��Ѵ�. */
                        int result = await _repo.ActivateUserAsync(Token);

                        if (result > 0)
                        {
                            ResultMessage = "�������� Ȱ��ȭ�Ǿ����ϴ�.";
                            isSuccess = true;
                        }
                        else
                        {
                            ResultMessage = "�������� Ȱ��ȭ���� �ʾҽ��ϴ�.";
                            isSuccess = false;
                        }
                    }
                }
                else
                {
                    ResultMessage = "ȸ������ �õ��� ���� �ʾҽ��ϴ�.";
                    isSuccess = false;
                }
            }
            IsSuccess = isSuccess;
            resultMessage = ResultMessage;
        }


    }
}
