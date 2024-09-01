using CRUD_APP_Using_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CRUD_APP_Using_API.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7188/api/StudentAPI/";
        private HttpClient client = new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode) { 
            
            string result=response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Create() { 
        return View();
        }
        
        [HttpPost]
        public IActionResult Create(Student std) { 
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode) {
                TempData["insert_message"] = "Student Added";
                return RedirectToAction("Index");
            }
        return View();
        }
       
}
    }

