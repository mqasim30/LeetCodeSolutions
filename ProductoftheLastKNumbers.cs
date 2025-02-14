namespace LeetCode.ProductoftheLastKNumbers;

public class ProductOfNumbers
{
    private List<int> prefixProducts = new List<int>() { 1 };

    public ProductOfNumbers()
    {

    }

    public void Add(int num)
    {
        if (num == 0)
        {
            prefixProducts = new List<int>() { 1 };
        }
        else
        {
            prefixProducts.Add(prefixProducts.Last() * num);
        }
    }

    public int GetProduct(int k)
    {
        if (k >= prefixProducts.Count)
        {
            return 0;
        }
        return prefixProducts.Last() / prefixProducts[prefixProducts.Count - k - 1];
    }
}