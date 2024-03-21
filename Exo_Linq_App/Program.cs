using Exo_Linq_Context;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Exercice Linq");
Console.WriteLine("*************");

DataContext context = new DataContext();

/*
 * 2.1 Exercice 2.1	Ecrire une requête pour présenter, 
 * pour chaque étudiant,  le nom de l’étudiant, la date de naissance, 
 * le login et le résultat pour l’année de l’ensemble des étudiants.
 */
var student1 = context.Students.Select(s => new { 
    nomEtudiant = s.Last_Name,
    dateDeNaissance = s.BirthDate,
    login = s.Login,
    resultatAnnee = s.Year_Result
    });

foreach (var item in student1)
{
    
    Console.WriteLine($"{item.nomEtudiant} {item.dateDeNaissance} {item.resultatAnnee} {item.login}");
}
Console.WriteLine("**********************************");

/*
 Exercice 2.2	Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom et prénom séparés par un espace), son id et sa date de naissance.
 */

var student2 = context.Students.Select(s => new {
        nomComplet = s.Last_Name + " " + s.First_Name,
        id = s.Student_ID,
        dateDeNaissance = s.BirthDate
        });
foreach (var item in student2)
{
    Console.WriteLine($"{item.id} {item.nomComplet} {item.dateDeNaissance}");
}
Console.WriteLine("**********************************");
/*
 * Exercice 2.3	Ecrire une requête pour présenter, pour chaque étudiant, dans une seule chaine de caractère l’ensemble des données relatives à un étudiant séparées par le symbole |.
 */
var student3 = context.Students.Select(s => new {
        fullDonnees = s.Student_ID + "|" + s.Last_Name + "|" + s.First_Name + "|" + s.BirthDate + "|" + s.Login + "|" + s.Year_Result + "|" + s.Section_ID + "|" + s.Course_ID
});
foreach (var item in student3)
{
    Console.WriteLine(item.fullDonnees);
}
Console.WriteLine("**********************************");

/*
 * Exercice 3.1	Pour chaque étudiant né avant 1955, donner  le nom, le résultat annuel et le statut. Le statut prend la valeur « OK » si l’étudiant à obtenu au moins 12 comme résultat annuel et « KO » dans le cas contraire. 
 */
var student4 = context.Students.Where(s => s.BirthDate.Year > 1955).Select(s => new { 
        nom = s.First_Name,
        resultatAnnuel = s.Year_Result,
        statut = s.Year_Result >= 12 ? "ok" : "Nok" 
        });
foreach (var item in student4)
{
    Console.WriteLine($"{item.nom} {item.statut} {item.resultatAnnuel}");
}
Console.WriteLine("**********************************");
/*
 * Exercice 3.2	Donner pour chaque étudiant entre 1955 et 1965 le nom, le résultat annuel et la catégorie à laquelle il appartient. La catégorie est fonction du résultat annuel obtenu ; un résultat inférieur à 10 appartient à la catégorie « inférieure », un résultat égal à 10 appartient à la catégorie « neutre », un résultat autre appartient à la catégorie « supérieure ».
 */

var student5 = context.Students.Where(s => s.BirthDate.Year > 1955 && s.BirthDate.Year < 1965).Select(s => new {
    nom = s.Last_Name,
    resultatannuel = s.Year_Result,
    categorie = s.Year_Result > 10 ? "supérieur" : s.Year_Result == 10 ? "Neutre" : "Inférieur"
});

foreach (var item in student5)
{
    Console.WriteLine($"{item.nom} {item.resultatannuel} {item.categorie}");
}
Console.WriteLine("**********************************");
/*
 * Exercice 3.3	Ecrire une requête pour présenter le nom, l’id de section et de tous les étudiants qui ont un nom de famille qui termine par r.
 */
var student6 = context.Students.Where(s => s.Last_Name.EndsWith('r')).Select(s => new
{
    
    nom = s.Last_Name,
    section = s.Section_ID,

});
foreach (var item in student6) {
    Console.WriteLine($"{item.nom} {item.section}");

}
Console.WriteLine("**********************************");
/*
 Exercice 3.4	Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats annuels décroissant de tous les étudiants qui ont obtenu un résultat annuel inférieur ou égal à 3.
 */

var student7 = context.Students.Where(s =>s.Year_Result <= 3 ).Select(s => new
{
    nom = s.Last_Name,
    anneeResultat = s.Year_Result
}).OrderByDescending( s => s.anneeResultat);

foreach (var item in student7)
{
    Console.WriteLine($"{item.nom} {item.anneeResultat}");
}
Console.WriteLine("**********************************");
/*
 Exercice 3.5	Ecrire une requête pour présenter le nom complet (nom et prénom séparés par un espace) et le résultat annuel classé par nom croissant sur le nom de tous les étudiants appartenant à la section 1110.
 */
var student8 = context.Students.Where(s => s.Section_ID == 1110)
                                .OrderBy(s => s.Last_Name)
                                .Select(s => new { 
    nomComplet = s.Last_Name + " " + s.First_Name,
    resultatAnnuel = s.Year_Result
    });
foreach (var item in student8)
{
    Console.WriteLine($"{item.nomComplet} {item.resultatAnnuel}");
}
Console.WriteLine("**********************************");
/*
 Exercice 3.6	Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel classé par ordre croissant sur la section de tous les étudiants appartenant aux sections 1010 et 1020 ayant un résultat annuel qui n’est pas compris entre 12 et 18.
 */

var student9 = context.Students.Where(s => s.Section_ID == 1010 || s.Section_ID == 1020)
                               .Where(s => s.Year_Result < 12 || s.Year_Result > 18)
                               .OrderBy(s => s.Section_ID)
                               .Select(s => new
                               {
                                   nom = s.Last_Name,
                                   id = s.Section_ID,
                                   anneeResultat = s.Year_Result
                               });

foreach (var item in student9)
{
    Console.WriteLine($"{item.id} {item.nom} {item.anneeResultat}");
}
Console.WriteLine("**********************************");

/*
 Exercice 3.7	Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur 100 (nommer la colonne ‘result_100’) classé par ordre décroissant du résultat de tous les étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100 inférieur ou égal à 60.
 */

var student10 = context.Students.Where(s => s.Section_ID.ToString().StartsWith("13")).OrderByDescending(s => s.Year_Result).Select( s => new
{
    nom = s.Last_Name,
    id = s.Student_ID,
    section = s.Section_ID,
    result100 = s.Year_Result * 5
}).Where(s => s.result100 <= 60);

foreach (var item in student10)
{
    Console.WriteLine($"{item.nom} {item.id} {item.section} {item.result100}");
}
Console.WriteLine("**********************************");


/*
Exercice 4.1	Donner le résultat annuel moyen pour l’ensemble des étudiants.
*/
var student11 = (int)context.Students.Average(s => s.Year_Result);

Console.WriteLine(student11);
Console.WriteLine("**********************************");

/*
Exercice 4.2	Donner le plus haut résultat annuel obtenu par un étudiant.
*/
var student12 = (int)context.Students.Max(s => s.Year_Result);

Console.WriteLine(student12);
Console.WriteLine("**********************************");

/*
Exercice 4.3	Donner la somme des résultats annuels.
*/
var student13 = (int)context.Students.Sum(s => s.Year_Result);

Console.WriteLine(student13);
Console.WriteLine("**********************************");

/*
Exercice 4.4	Donner le résultat annuel le plus faible.
*/
var student14 = (int)context.Students.Min(s => s.Year_Result);

Console.WriteLine(student14);
Console.WriteLine("**********************************");
/*
Exercice 4.5	Donner le nombre de lignes qui composent la séquence « Students » ayant obtenu un résultat annuel impair.
 */
var student15 = context.Students.Where(s => s.Year_Result % 2 != 0 ).Count();

Console.WriteLine(student15);
Console.WriteLine("**********************************");



/*
 Exercice 5.1	Donner pour chaque section, le résultat maximum (« Max_Result ») obtenu par les étudiants.
*/
var student16 = context.Students.GroupBy(s => s.Section_ID).Select(s => new { section = s.Key , maxResult = s.Max( g => g.Year_Result)});


foreach (var item in student16)
{
    Console.WriteLine($"{item.section} : {item.maxResult}");
}
Console.WriteLine("**********************************");
/*
Exercice 5.2	Donner pour toutes les sections commençant par 10, le résultat annuel moyen (« AVGResult ») obtenu par les étudiants.
*/
var student17 = context.Students.Where(s => s.Section_ID.ToString().StartsWith("10")).GroupBy(s => s.Section_ID).Select( s => new
{
    section = s.Key,
    avgResult = s.Average( g => g.Year_Result )
} );

foreach (var item in student17)
{
    Console.WriteLine($"{item.section} {item.avgResult}");
}
Console.WriteLine("**********************************");
/*
Exercice 5.3	Donner le résultat moyen (« AVGResult ») et le mois en chiffre (« BirthMonth ») pour les étudiants né le même mois entre 1970 et 1985.
*/
var student18 = context.Students.Where(s => s.BirthDate.Year > 1970 && s.BirthDate.Year < 1985).GroupBy(s => s.BirthDate.Month).Select(s => new
{
    mois = s.Key,
    avgResult = s.Average(g => g.Year_Result)
});

foreach (var item in student18)
{
    Console.WriteLine($"{item.mois} {item.avgResult}");
}
Console.WriteLine("**********************************");

/*
Exercice 5.4	Donner pour toutes les sections qui compte plus de 3 étudiants, la moyenne des résultats annuels (« AVGResult »).
*/

var student19 = context.Students.GroupBy(s => s.Section_ID).Where(s => s.Count()  > 3 ).Select(s => new
{
    section = s.Key,
    avgResult = s.Average(g => g.Year_Result)
});

foreach (var item in student19)
{
    Console.WriteLine($"{item.section} {item.avgResult}");
}
Console.WriteLine("**********************************");

/*
Exercice 5.5	Donner pour chaque cours, le nom du professeur responsable ainsi que la section dont le professeur fait partie.

 */