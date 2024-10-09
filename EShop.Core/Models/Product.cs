namespace EShop.Core.Models;
public class Product
{
    private Product(string title, string description, string imageUrl)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
    }

    public Guid Id { get; }

    public string Title { get; }

    public string Description { get; }

    public string ImageUrl { get; }

    public static Product Create(string title, string description, string imageUrl) 
    {
        ValidateUserInput(title, description, imageUrl);

        return new Product(title, description, imageUrl);
    }

    private static void ValidateUserInput(string title, string description, string imageUrl) 
    {
        if (string.IsNullOrEmpty(title)) 
        {
            throw new ArgumentNullException(nameof(title), "Title cannot be null or empty");
        }
        if (title.Length < 1 || title.Length > 100) 
        {
            throw new ArgumentException(nameof(title), "Title length must be between 1 and 100");
        }

        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(nameof(description), "Description cannot be null or empty");
        }
        if (description.Length < 1 || description.Length > 100)
        {
            throw new ArgumentException(nameof(description), "Title length must be between 1 and 100");
        }

        if (string.IsNullOrEmpty(imageUrl)) 
        {
            throw new ArgumentNullException(nameof(imageUrl));
        }
    }
}
