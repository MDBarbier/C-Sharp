namespace CDSystem
{
    public class CD
    {
        public int Stock { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public string Name { get; set; }       

        public void LeaveReview(int rating, string review, Warehouse warehouse)
        {
            if (warehouse.GetCdFromInventory(Name) != null)
            {
                Rating = rating;
                Review = review;
            }
        }
    }
}
