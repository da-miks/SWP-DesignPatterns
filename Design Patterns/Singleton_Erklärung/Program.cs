
using Singleton_Erklärung;

//Verwendung des Singleton
UserContextEarly myContext = UserContextEarly.Instance;
Console.WriteLine(myContext == UserContextEarly.Instance);

/*Zusammengefasst:
 * Wird verwendet wenn man eine globale Variable benötigt die in vielen Programmteilen verwendet wird
 * Constructor wird private gemacht damit man kein Objekt davon erstellen kann
 * Eine Zugriffsfunktion oder eine Eigenschaft kann nun aber diese Instanz liefern
 * bei der späten Initialisierung wird erst das Objekt beim ersten Zugriff darauf initialisiert
 * bei der frühen Intialisierung wird das Objekt gleich bei der Deklaration der Instanz initialisiert
 * Multi-Threading wird ein Problem
*/

UserContextEarly_ myContextearly = UserContextEarly_.Instance;