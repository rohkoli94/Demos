using System.Collections.Generic;
using System.Web.Http;

namespace ServerApp.Controllers
{
    using Models;

    public class FeedbacksController : ApiController
    {
        private Document<Feedback> doc;

        public FeedbacksController()
        {
            doc = Document<Feedback>.Open("feedbacks.xml");
        }

        public IEnumerable<Feedback> Get()
        {
            return doc;
        }

        public IHttpActionResult Get(string id)
        {
            Feedback feedback = doc.Find(entry => entry.From == id);

            if (feedback == null)
                return NotFound();

            return Ok(feedback);
        }

        public string Post(Feedback input)
        {
            Feedback feedback = doc.Find(entry => entry.From == input.From);
            string result;

            if(feedback == null)
            {
                doc.Add(input);
                result = "Accepted";
            }
            else
            {
                feedback.Comment = input.Comment;
                result = "Modified";
            }

            doc.Save();

            return result;

        }
    }
}
