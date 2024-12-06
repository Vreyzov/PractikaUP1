using System;
using System.Linq;
using EquipmentForRent.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryEquipment
{
        public class AuthService
        {
            private readonly EquipmentRentContext _context;

            public AuthService(EquipmentRentContext context)
            {
                _context = context;
            }

            public string Login(string login, string password)
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    return "Логин и пароль обязательны!";
                }

                var client = _context.Clients.FirstOrDefault(c => c.Login == login && c.Password == password);
                var lessor = _context.Lessors.FirstOrDefault(l => l.Login == login && l.Password == password);

                if (client != null)
                {
                    return "ClientHomePage"; // Возвращаем строку для примера
                }
                else if (lessor != null)
                {
                    return "LessorHomePage";
                }
                else
                {
                    return "Неверный логин или пароль!";
                }
            }
        }
    }
