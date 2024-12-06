using EquipmentForRent.Models;
using LibraryEquipment;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectEquipment
{
    [TestClass]
    public class AuthServiceTests
    {
        private EquipmentRentContext _context;
        private AuthService _authService;

        [TestInitialize]
        public void Initialize()
        {
            // Настроим SQL Server базу данных для тестов
            var options = new DbContextOptionsBuilder<EquipmentRentContext>()
                .UseSqlServer("Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;")
                .Options;

            _context = new EquipmentRentContext(options);

            // Убедитесь, что база данных создана
            _context.Database.EnsureCreated();

            // Создаем экземпляр AuthService
            _authService = new AuthService(_context);
        }

        [TestMethod]
        public void Login_ShouldReturnClientHomePage_ForValidClientCredentials()
        {
            // Arrange
            string login = "ivanob"; // Логин существующего клиента
            string password = "pass123"; // Пароль существующего клиента

            // Act
            string result = _authService.Login(login, password);

            // Assert
            Assert.AreEqual("ClientHomePage", result);
        }
        [TestMethod]
        public void Login_ShouldReturnLessorHomePage_ForValidClientCredentials()
        {
            // Arrange
            string login = "morozob"; // Логин существующего арендодателя
            string password = "lessor123"; // Пароль существующего арендодателя

            // Act
            string result = _authService.Login(login, password);

            // Assert
            Assert.AreEqual("LessorHomePage", result);
        }
    }
}