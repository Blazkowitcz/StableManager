using StableManager.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StableManager.Classes
{


    public class FrameClass
    {
        public MainWindow mainWindow;
        public MainMenu mainMenu;
        public MenuChevaux menuChevaux;
        public GestionEcurie gestionEcurie;
        public GererChevaux gererChevaux;
        public Frame frame;
        public DatabaseManager databaseManager;
        public AjouterCheval ajouterCheval;
        public InfoCheval infoCheval;
        public InfoProprietaire infoProprietaire;

        public FrameClass(MainWindow mainWindow, Frame frame, DatabaseManager databaseManager)
        {
            this.mainWindow = mainWindow;
            this.frame = frame;
            this.databaseManager = databaseManager;
            mainMenu = new MainMenu(mainWindow);
            menuChevaux = new MenuChevaux(databaseManager, mainWindow);
            gestionEcurie = new GestionEcurie(mainWindow);
            gererChevaux = new GererChevaux(mainWindow);
            ajouterCheval = new AjouterCheval(mainWindow, databaseManager);
            infoCheval = new InfoCheval(mainWindow, databaseManager);
            infoProprietaire = new InfoProprietaire(mainWindow, databaseManager);
        }

        public void ChangeFrame(Page page)
        {
            frame.Navigate(page);
        }


    }
}
