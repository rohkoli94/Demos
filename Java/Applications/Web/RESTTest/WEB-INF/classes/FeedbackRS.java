package survey;

import java.util.*;
import javax.ws.rs.*;
import javax.ws.rs.core.*;

@Path("/feedbacks")
public class FeedbackRS{

	private Document<FeedbackInfo> doc;

	public FeedbackRS(){
		doc = Document.open(FeedbackInfo.class, "feedbacks.xml");
	}

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public List<FeedbackInfo> readFeedbacks(){
		return doc;
	}

	@GET
	@Path("/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response readFeedback(@PathParam("id") String name){
		FeedbackInfo info = doc.find(f -> f.from.equals(name));
		if(info != null)
			return Response.ok(info).build();
		return Response.status(Response.Status.NOT_FOUND).build();
	}

	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public String writeFeedback(FeedbackInfo feedback){
		FeedbackInfo info = doc.find(f -> f.from.equals(feedback.from));
		String result;
		if(info == null){
			doc.add(feedback);
			result = "Accepted";
		}else{
			info.comment = feedback.comment;
			result = "Modified";
		}
		doc.save();
		return result;
	}
}

