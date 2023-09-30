using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Employee.Frontend.Controllers;

public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;
    public EmployeeController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApiBase");

    public async Task<IActionResult> Index() => View(await GetAllEmployee());

    public async Task<List<Employees>> GetAllEmployee()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Employees>>("Employee");

        return response is not null? response : new List<Employees>();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employees employees)
    {
        if (ModelState.IsValid)
        {

                // Serialize the employee object to JSON
                var jsonContent = JsonConvert.SerializeObject(employees);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Make a POST request to create the employee
                var response = await _httpClient.PostAsync("Employee", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error creating employee.");
                }
            

        }

        // If the POST request fails or ModelState is not valid, return to the Create view
        return View(employees);
    }

    public async Task<IActionResult> AddOrEdit(int Id)
    {
        if (Id == 0)
        {
            return View(new Employees());
        } else
        {
            var data = await _httpClient.GetAsync($"Employee/{Id}");
            if (data.IsSuccessStatusCode)
            {
                var result = await data.Content.ReadFromJsonAsync<Employees>();
                return View(result);
            }
        }
        return View(new Employees());
    }

}