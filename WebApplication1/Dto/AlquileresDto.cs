namespace BibliotecaAPI.Dto
{
    public class AlquileresDto
    {
        public int cliente { get; set; }
        public string isbn { get; set; }
        public int estado { get;  set; }

        public AlquileresDto(int cliente,string isbn,int estado)
        {
            this.cliente = cliente;
            this.isbn = isbn;
            this.estado = estado;
        }
    }
}
