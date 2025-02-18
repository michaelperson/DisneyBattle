namespace DisneyBattle.BLL.Models;

public class UtilisateurModel
{
    // Propri�t�s � d�finir selon l'entit�
    public int Id { get; set; }
    public string Pseudo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MotDePasse { get; set; } = null!;

    public DateTime? DateInscription { get; set; }

    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }

}
