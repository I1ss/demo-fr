namespace BL.Models
{
    /// <summary>
    /// Модель действий.
    /// </summary>
    public class ActivityTotals
    {
        /// <summary>
        /// Типовое распределение - Аналитика.
        /// </summary>
        public decimal Analytics { get; set; }

        /// <summary>
        /// Трудозатраты - аналитика.
        /// </summary>
        public double AnalyticsLaborCosts { get; set; }

        /// <summary>
        /// Типовое распределение - Разработка.
        /// </summary>
        public decimal Development { get; set; }

        /// <summary>
        /// Трудозатраты - разработка.
        /// </summary>
        public double DevelopmentLaborCosts { get; set; }

        /// <summary>
        /// Типовое распределение - Управление.
        /// </summary>
        public decimal Management { get; set; }

        /// <summary>
        /// Трудозатраты - управление.
        /// </summary>
        public double ManagementLaborCosts { get; set; }

        /// <summary>
        /// Технический долг.
        /// </summary>
        public decimal TechnicalDebt { get; set; }

        /// <summary>
        /// Типовое распределение - Тестирование.
        /// </summary>
        public decimal Testing { get; set; }

        /// <summary>
        /// Трудозатраты - тестирование.
        /// </summary>
        public double TestingLaborCosts { get; set; }
    }
}