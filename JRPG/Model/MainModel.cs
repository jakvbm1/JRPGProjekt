namespace JRPG.Model
{
    class MainModel
    {
        public UsersModel usersModel;
        public CharactersModel charactersModel;
        public ClassesModel classesModel;
        public EnemiesModel enemiesModel;
        public ItemsModel itemsModel;
        public MainScreenModel msn;
        public ShopScreenModel shopScreenModel;
        public AdminPanelModel adminPanelModel;
        
    public MainModel()
        {
            charactersModel = new CharactersModel();
            usersModel = new UsersModel();
            classesModel = new ClassesModel();
            enemiesModel = new EnemiesModel();
            itemsModel = new ItemsModel();
            msn = new MainScreenModel();
            shopScreenModel = new ShopScreenModel();
            adminPanelModel = new AdminPanelModel();
        }
    }
}
