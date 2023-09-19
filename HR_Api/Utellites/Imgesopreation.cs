namespace HR_Api.Utellites
{

    public class Imgoperation
    {

        IWebHostEnvironment webHostEnvironment;

        public Imgoperation(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public string Uploadimg(IFormFile formFiles)
        {
            string filename = null;
            if (formFiles != null)
            {

                string filledirectory = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                filename = Guid.NewGuid() + "-" + formFiles.FileName;
                string filepath = Path.Combine(filledirectory, filename);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    formFiles.CopyToAsync(fs);
                }
            }
            return filename;

        }








        public string Addrengofimges(IFormFile image)
        {

            if (image != null)
            {

                // Generate a unique file name using GUID to avoid name conflicts
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var newImagePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);

                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // Return the new file path
                return $"/Images/{fileName}"; // Store the relative path to the image

            }
            return null;
        }
    }
}
