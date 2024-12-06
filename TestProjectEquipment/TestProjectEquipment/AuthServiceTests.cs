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
            // �������� SQL Server ���� ������ ��� ������
            var options = new DbContextOptionsBuilder<EquipmentRentContext>()
                .UseSqlServer("Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;")
                .Options;

            _context = new EquipmentRentContext(options);

            // ���������, ��� ���� ������ �������
            _context.Database.EnsureCreated();

            // ������� ��������� AuthService
            _authService = new AuthService(_context);
        }

        [TestMethod]
        public void Login_ShouldReturnClientHomePage_ForValidClientCredentials()
        {
            // Arrange
            string login = "ivanob"; // ����� ������������� �������
            string password = "pass123"; // ������ ������������� �������

            // Act
            string result = _authService.Login(login, password);

            // Assert
            Assert.AreEqual("ClientHomePage", result);
        }
        [TestMethod]
        public void Login_ShouldReturnLessorHomePage_ForValidClientCredentials()
        {
            // Arrange
            string login = "morozob"; // ����� ������������� ������������
            string password = "lessor123"; // ������ ������������� ������������

            // Act
            string result = _authService.Login(login, password);

            // Assert
            Assert.AreEqual("LessorHomePage", result);
        }
    }
}