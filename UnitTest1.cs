using Microsoft.Playwright;

namespace MyPlaywright
{
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500, Timeout = 80000, }
                );

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);
            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.ClickAsync("text=New User Register Here");

            await page.FillAsync("input[name='username']", "FatimaSaleem112");
            await page.FillAsync("input[name='password']", "FatimaSaleem");
            await page.FillAsync("input[name='re_password']", "FatimaSaleem");
            await page.FillAsync("input[name='full_name']", "FatimaSaleem");
            await page.FillAsync("input[name='email_add']", "fasaleem112@gmail.com");
            // Manually write Captcha
            await page.PauseAsync(); 

            await page.CheckAsync("input[name='tnc_box']");
            await page.ClickAsync("input[type='submit']");

            // Wait for success and then click the login link
            await page.WaitForSelectorAsync("text=Click here to login");
            await page.ClickAsync("text=Click here to login");

            await page.FillAsync("#username", "fatimaSaleem");
            await page.FillAsync("#password", "fatimaSaleem");
            await page.ClickAsync("#login");

            // Optional: wait for confirmation or next page
            await page.WaitForTimeoutAsync(3000);
        }

    }
} 