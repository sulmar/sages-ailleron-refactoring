using System;

namespace SingletonPattern
{
    public class ApplicationContext : ThreadSafeSingleton<ApplicationContext>
    {
        public string LoggedUser { get; set; }
        public DateTime LoggedOn { get; set; }

        // TODO: Zastosuj Wzorzec Mediator
        public int SelectedCustomerId { get; set; }
        public int SelectedProductId { get; set; }
    }
}
