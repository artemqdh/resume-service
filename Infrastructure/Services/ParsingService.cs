using Application.IService;
using Domain.Entity;
using PuppeteerSharp;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Services
{
    public class ParsingService : IParsingService
    {
        public async Task<Vacancy?> ParsingUrl(string url)
        {
            try
            {
                using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
                });

                using var page = await browser.NewPageAsync();

                // Устанавливаем User-Agent, чтобы сайт не блокировал запрос
                await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

                await page.GoToAsync(url, WaitUntilNavigation.Networkidle2);

                // Извлекаем содержимое тега script с типом application/ld+json
                var jsonLdRaw = await page.EvaluateExpressionAsync<string>(
                    "document.querySelector('script[type=\"application/ld+json\"]').innerText"
                );

                if (string.IsNullOrEmpty(jsonLdRaw)) return null;

                // Парсим JSON
                var data = JObject.Parse(jsonLdRaw);


                return new Vacancy
                {
                    Title = data["title"]?.ToString() ?? "Без названия",
                    // Название компании находится в объекте hiringOrganization
                    Description = data["description"]?.ToString() ?? "",
                    Country = data["jobLocation"]?["address"]?["addressLocality"]?.ToString(),
                    // Пример получения организации: (string)data["hiringOrganization"]?["name"]
                   // WorkSchedule = data["employmentType"]?.ToString()
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
