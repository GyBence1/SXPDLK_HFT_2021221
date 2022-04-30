using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SXPDLK_HFT_2021221.WPFClient
{
    public class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<Guitar> Guitars { get; set; }
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Purchase> Purchases { get; set; }
        //BRAND COMMANDS
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        // GUITAR COMMANDS
        public ICommand CreateGuitarCommand { get; set; }
        public ICommand DeleteGuitarCommand { get; set; }
        public ICommand UpdateGuitarCommand { get; set; }
        //PURCHASE COMMANDS
        public ICommand CreatePurchaseCommand { get; set; }
        public ICommand DeletePurchaseCommand { get; set; }
        public ICommand UpdatePurchaseCommand { get; set; }
        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value!=null)
                {
                    selectedBrand=new Brand()
                    {
                        Name=value.Name,
                        Id=value.Id
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
             
            }
        }

        private Guitar selectedGuitar;

        public Guitar SelectedGuitar
        {
            get { return selectedGuitar; }
            set {
                if (value!=null)
                {
                    selectedGuitar=new Guitar()
                    {
                        Id=value.Id,
                        Model=value.Model
                    };
                    OnPropertyChanged();
                    (DeleteGuitarCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Purchase selectedPurchase;

        public Purchase SelectedPurchase
        {
            get { return selectedPurchase; }
            set
            {
                if (value!=null)
                {
                    selectedPurchase=new Purchase()
                    {
                        Id = value.Id,
                        BuyerName=value.BuyerName,
                        GuitarId=value.GuitarId,
                    };
                    OnPropertyChanged();
                    (DeletePurchaseCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
           
            if (!IsInDesignMode)
            {
                Guitars=new RestCollection<Guitar>("http://localhost:43375/", "guitar","hub");
                Brands=new RestCollection<Brand>("http://localhost:43375/", "brand", "hub");
                Purchases=new RestCollection<Purchase>("http://localhost:43375/", "purchase", "hub");

                CreateBrandCommand=new RelayCommand(() =>
                Brands.Add(new Brand()
                {
                    Name=selectedBrand.Name
                })
                );

                DeleteBrandCommand=new RelayCommand(() =>
                Brands.Delete(SelectedBrand.Id),
                () => selectedBrand!=null
                );
                UpdateBrandCommand=new RelayCommand(() =>
                Brands.Update(SelectedBrand),
                () => SelectedBrand!=null);

                CreateGuitarCommand=new RelayCommand(() =>
               Guitars.Add(new Guitar()
               {
                   Model=SelectedGuitar.Model,
                   BrandId=SelectedBrand.Id
               })
               );

                DeleteGuitarCommand=new RelayCommand(() =>
                Guitars.Delete(SelectedGuitar.Id),
                () => selectedGuitar!=null
                );
                UpdateGuitarCommand=new RelayCommand(() =>
                Guitars.Update(SelectedGuitar),
                () => SelectedGuitar!=null);

                CreatePurchaseCommand=new RelayCommand(() =>
               Purchases.Add(new Purchase()
               {
                   BuyerName=selectedPurchase.BuyerName,
                   GuitarId=selectedGuitar.Id
               })
               );

                UpdatePurchaseCommand=new RelayCommand(() =>
                Purchases.Update(SelectedPurchase),
                () => SelectedPurchase!=null);

                DeletePurchaseCommand=new RelayCommand(() =>
                Purchases.Delete(SelectedPurchase.Id),
                () => SelectedPurchase!=null
                );
                SelectedPurchase = new Purchase();
                SelectedGuitar = new Guitar();
                SelectedBrand = new Brand();
            }
        }
        }
    }
