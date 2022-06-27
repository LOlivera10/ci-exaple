namespace BibliotecaAPI.Dto
{
    public class ClienteDto
    {
        public int Dni { get; set; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Email { get; }

        public ClienteDto(int Dni  ,string Nombre = "",string Apellido = "",string Email = "")
        {
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Email = Email;
        }
    }
}
