using Adapter_Erklärung;

Scene scene = new Scene();
scene.ItemsInScene.Add(new Circle());
scene.ItemsInScene.Add(new FractalDrawableAdapter(new MountainGenerator()));
scene.ItemsInScene.Add(new PlottingDrawableAdapter(new MapPlotter()));
scene.Draw();

/*
 * Nur ein Adapter pro Klasse die man "wechseln" will
 * bedeutet Neues Interface bedeutet gleich neuer Adapter der die Draw Funktion wieder umshiftet auf das IDrawable
*/