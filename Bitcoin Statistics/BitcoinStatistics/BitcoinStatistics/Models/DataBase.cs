using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Data.Linq.Mapping;
using System.Collections.ObjectModel;
using System.Data.Linq;

namespace BitcoinStatistics.Models
{

    [Table]
    public class TileUpdateDB : INotifyPropertyChanged
    {
        // Define ID: private field, public property and database column.
        private int _tileUpdateId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int TileUpdateId
        {
            get
            {
                return _tileUpdateId;
            }
            set
            {
                if (_tileUpdateId != value)
                {
                    //NotifyPropertyChanging("TileUpdateId");
                    _tileUpdateId = value;
                    NotifyPropertyChanged("TileUpdateId");
                }
            }
        }

        // Define seeTile: private field, public property and database column.
        private bool _seeTile;

        [Column]
        public bool SeeTile
        {
            get
            {
                return _seeTile;
            }
            set
            {
                if (_seeTile != value)
                {
                    //NotifyPropertyChanging("SeeTile");
                    _seeTile = value;
                    NotifyPropertyChanged("SeeTile");
                }
            }
        }

        // Define modelTile: private field, public property and database column.
        private string _modelTile;

        [Column]
        public string ModelTile
        {
            get
            {
                return _modelTile;
            }
            set
            {
                if (_modelTile != value)
                {
                    //NotifyPropertyChanging("ModelTile");
                    _modelTile = value;
                    NotifyPropertyChanged("ModelTile");
                }
            }
        }

        // Define lastValueTile: private field, public property and database column.
        private string _valueTile;

        [Column]
        public string ValueTile
        {
            get
            {
                return _valueTile;
            }
            set
            {
                if (_valueTile != value)
                {
                    //NotifyPropertyChanging("ValueTile");
                    _valueTile = value;
                    NotifyPropertyChanged("ValueTile");
                }
            }
        }

        // Define currencyTile: private field, public property and database column.
        private string _currencyTile;

        [Column]
        public string CurrencyTile
        {
            get
            {
                return _currencyTile;
            }
            set
            {
                if (_currencyTile != value)
                {
                    //NotifyPropertyChanging("CurrencyTile");
                    _currencyTile = value;
                    NotifyPropertyChanged("CurrencyTile");
                }
            }
        }

        // Define lastUpdateTile: private field, public property and database column.
        private string _updateTile;

        [Column]
        public string UpdateTile
        {
            get
            {
                return _updateTile;
            }
            set
            {
                if (_updateTile != value)
                {
                    //NotifyPropertyChanging("UpdateTile");
                    _updateTile = value;
                    NotifyPropertyChanged("UpdateTile");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
