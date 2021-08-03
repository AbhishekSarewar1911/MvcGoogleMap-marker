using MvcGoogleMap_Demo;
using MvcGoogleMap_Demo.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MvcGoogleMap_Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
      //  public ActionResult Index()
        //{
          //  return View();
        //}
        public ActionResult Location()
        {
            string markers = "[";
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    markers += "{";
                    markers += string.Format("'title': '{0}',", sdr["Name"]);
                    markers += string.Format("'title': '{0}',", sdr["City"]);
                    markers += string.Format("'title': '{0}',", sdr["State"]);
                    markers += string.Format("'title': '{0}',", sdr["Pincode"]);
                    markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                    markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                    markers += string.Format("'description': '{0}'", sdr["Description"]);
                    markers += "},";
                }
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
        [HttpPost]
        public ActionResult Location(Locations location)
        {
            if (ModelState.IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewLocation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", location.Name);
                    cmd.Parameters.AddWithValue("@City", location.City);
                    cmd.Parameters.AddWithValue("@State", location.State);
                    cmd.Parameters.AddWithValue("@Pincode", location.Pincode);
                    cmd.Parameters.AddWithValue("@Latitude", location.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", location.Longitude);
                    cmd.Parameters.AddWithValue("@Description", location.Description);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {

            }
            return RedirectToAction("Location");
        }
    }
}
