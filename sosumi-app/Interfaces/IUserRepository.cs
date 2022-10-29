﻿using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<Item> GetFavoritesByUserId(int id);
    }
}
