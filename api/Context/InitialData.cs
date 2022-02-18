namespace api.Context
{
    public static class InitialData
    {
        public static void Seed(this DocumentsContext dbContext)
        {
            if (!dbContext.Documents.Any())
            {
                dbContext.Documents.Add(new Models.Document()
                {
                    Title = "Documento 1",
                    Description = "Documento demonstração"
                });
                dbContext.SaveChanges();
            }
        }
    }
}
