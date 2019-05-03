using Flunt.Notifications;
using Flunt.Validations;

namespace WebAPI.ViewModels.UsuariosViewModels
{
    public class EditorUsuariosViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Celular { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Nome, 50, "Nome", "O Nome pode conter até 50 caracteres")
                    .HasMinLen(Nome, 1, "Nome", "O Nome deve ser preenchido com pelo menos 3 caracteres")
            );
        }
    }
}