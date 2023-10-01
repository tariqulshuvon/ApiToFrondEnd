using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var response = await _httpClient.GetAsync("Country");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["countryId"] = new SelectList(countryList,"Id","CountryName");
        }
        var response2 = await _httpClient.GetAsync("State");
        if (response2.IsSuccessStatusCode)
        {
            var content = await response2.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            ViewData["stateId"] = new SelectList(stateList, "Id", "StateName");
        }
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

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> AddOrEdit(int Id, Employees employees)
    {

        if (ModelState.IsValid)
        {
            if (Id == 0)
            {
                var result = await _httpClient.PostAsJsonAsync("Employee", employees);

                if (result.IsSuccessStatusCode) return RedirectToAction("Index");

            }
            else
            {
                var result = await _httpClient.PutAsJsonAsync($"Employee/{Id}", employees);
                if (result.IsSuccessStatusCode) { return RedirectToAction("Index"); }
            }

        }
        return View(new Country());

    }

    public async Task<IActionResult> Delete(int Id)
    {
        var data = await _httpClient.DeleteAsync($"Employee/{Id}");
        if (data.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }

}