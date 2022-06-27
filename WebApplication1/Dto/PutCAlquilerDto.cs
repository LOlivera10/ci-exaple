namespace BibliotecaAPI.Dto
{
    public class PutCAlquilerDto
    {
        public int cliente { get; set; }
        public string ISBN { get; set; }
        public PutCAlquilerDto(int cliente,string ISBN)
        {
            this.cliente = cliente;
            this.ISBN = ISBN;
        }
    }
}
