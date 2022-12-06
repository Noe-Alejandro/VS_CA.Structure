using CA.Recipe.FrameworksDrivers.Data.Recipe;
using System;

namespace CA.Recipe.FrameworksDrivers
{
    public class UoWRecipe : IDisposable
    {
        public UoWRecipe()
        {
            Context = new RecipeContext();
            AmountRepository = new GenericRepository<Amount>(Context);
            IngredientRepository = new GenericRepository<Ingredient>(Context);
            RecipeRepository = new GenericRepository<Data.Recipe.Recipe>(Context);
            ScoreRepository = new GenericRepository<Score>(Context);
            UserRepository = new GenericRepository<User>(Context);
            WatchLaterRepository = new GenericRepository<WatchLater>(Context);
        }
        public RecipeContext Context { get; set; }
        public GenericRepository<Amount> AmountRepository { get; set; }
        public GenericRepository<Ingredient> IngredientRepository { get; set; }
        public GenericRepository<Data.Recipe.Recipe> RecipeRepository { get; set; }
        public GenericRepository<Score> ScoreRepository { get; set; }
        public GenericRepository<User> UserRepository { get; set; }

        public GenericRepository<WatchLater> WatchLaterRepository { get; set; }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool Disposing)
        {
            if (!this.Disposed)
            {
                if (Disposing)
                {
                    Context.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}