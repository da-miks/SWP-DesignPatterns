using Adapterpattern;

Scene myScene= new Scene();
myScene.List.Add(new Rectangle());
myScene.List.Add(new GenratorDrawableAdapter(new Mountain()));

myScene.MakeScene();