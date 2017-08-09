using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quotingdojo.Connectors;
using quotingdojo.Models;
 
namespace quotingdojo.Controllers
{
    public class QuoteController : Controller
    {
        // private DbConnector cnx;

        // public  QuoteController(){
        //     cnx=new DbConnector();
        // }
        // A GET method
[HttpGet]
 
[Route("")]
        public IActionResult Index()
        {
            // return View();
            // //OR
            string readq = "SELECT * FROM quotes";
            var allquotes =  DbConnector.Query(readq);
            ViewBag.allquotes = allquotes;
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
 

[HttpGet]
 
[Route("quotes")]
        public IActionResult quotes()
        {
            // return View();
            // //OR
            string readq = "SELECT * FROM quotes order by createdat DESC";
            var allquotes =  DbConnector.Query(readq);
            ViewBag.allquotes = allquotes;
            return View("Result");
            //Both of these returns will render the same view (You only need one!)
        }
// A POST method
 
[HttpPost]
[Route("process")]
public IActionResult processquote(Quote newquote)
{
    if(ModelState.IsValid)
    {
        string query = $"insert into quotes (username,quotesmsg,createdat,updatedat) VALUES ('{newquote.Username}','{newquote.Quotemsg}',Now(),Now())";
        DbConnector.Execute(query);
        
        return RedirectToAction("quotes");
    }
    else{
        ViewBag.errors = ModelState.Values;
        ViewBag.status="fail";
        return View("Index");

    }
     
//  return RedirectToAction("quotes");
}
    }
}