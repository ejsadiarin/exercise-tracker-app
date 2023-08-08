namespace API.Models;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    
    // This image property can be of Image type or blob, depending on the service (search AWS S3 or Cloudinary for scale)
    // public string Image { get; set; }
}