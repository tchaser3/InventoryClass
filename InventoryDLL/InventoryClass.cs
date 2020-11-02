/* Title:           Inventory Class
 * Date:            5-1-2016
 * Author:          Terry Holmes
 *
 * Description:     This is the inventory class for all inventory tables */

 /* Update:         Adding Part ID to tables
  * Date:           10-25-16
  * Author:         Terry Holmes
  * 
  * Description:    Added the part id to the tables and then changed the routines.
  */

  //Update:         Moved all functionality to SQL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace InventoryDLL
{
    public class InventoryClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        InventoryDataSet aInventoryDataSet;
        InventoryDataSetTableAdapters.inventoryTableAdapter aInventoryTableAdapter;

        InsertInventoryPartDataTableAdapters.QueriesTableAdapter aInsertInventoryPartTableAdapter;

        UpdateInventoryPartDataTableAdapters.QueriesTableAdapter aUpdateInventoryPartDataTableAdapter;

        FindCompleteInventoryDataSet aFindCompleteInventoryDataSet;
        FindCompleteInventoryDataSetTableAdapters.FindCompleteInventoryTableAdapter aFindCompleteInventoryTableAdapter;

        FindWarehouseInventoryDataSet aFindWarehouseInventoryDataSet;
        FindWarehouseInventoryDataSetTableAdapters.FindWarehouseInventoryTableAdapter aFindWarehouseInventoryTableAdapter;

        FindWarehouseInventoryPartDataSet aFindWarehouseInventoryPartDataSet;
        FindWarehouseInventoryPartDataSetTableAdapters.FindWarehouseInventoryPartTableAdapter aFindWarehouseInventoryPartTableAdapter;

        MovePartToNewWarehouseEntryTableAdapters.QueriesTableAdapter aMovePartToNewWarehouseTableAdapter;

        FindPartsListReportDataSet aFindPartsListReportDataSet;
        FindPartsListReportDataSetTableAdapters.FindPartsListReportTableAdapter aFindPartsListReportTableAdapter;

        ClearWarehouseInventoryEntryTableAdapters.QueriesTableAdapter aClearWarehouseInventoryTableAdpater;

        public bool ClearWarehouseInventory(int intWarehouseID)
        {
            bool blnFatalError = false;

            try
            {
                aClearWarehouseInventoryTableAdpater = new ClearWarehouseInventoryEntryTableAdapters.QueriesTableAdapter();
                aClearWarehouseInventoryTableAdpater.ClearWarehouseInventory(intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Clear Warehouse Inventory " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindPartsListReportDataSet FindPartsListReport()
        {
            try
            {
                aFindPartsListReportDataSet = new FindPartsListReportDataSet();
                aFindPartsListReportTableAdapter = new FindPartsListReportDataSetTableAdapters.FindPartsListReportTableAdapter();
                aFindPartsListReportTableAdapter.Fill(aFindPartsListReportDataSet.FindPartsListReport);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Find Parts List Report " + Ex.Message);
            }

            return aFindPartsListReportDataSet;
        }
        public bool MovePartToNewWarehouse(int intOldWarehouseID, int intNewWarehouseID, int intPartID)
        {
            bool blnFatalError = false;

            try
            {
                aMovePartToNewWarehouseTableAdapter = new MovePartToNewWarehouseEntryTableAdapters.QueriesTableAdapter();
                aMovePartToNewWarehouseTableAdapter.MovePartToNewWarehouse(intOldWarehouseID, intNewWarehouseID, intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Move Part To New Warehouse " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindWarehouseInventoryPartDataSet FindWarehouseInventoryPart(int intPartID, int intWarehouseID)
        {
            try
            {
                aFindWarehouseInventoryPartDataSet = new FindWarehouseInventoryPartDataSet();
                aFindWarehouseInventoryPartTableAdapter = new FindWarehouseInventoryPartDataSetTableAdapters.FindWarehouseInventoryPartTableAdapter();
                aFindWarehouseInventoryPartTableAdapter.Fill(aFindWarehouseInventoryPartDataSet.FindWarehouseInventoryPart, intPartID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Find Warehouse Inventory Part " + Ex.Message);
            }

            return aFindWarehouseInventoryPartDataSet;
        }
        public FindWarehouseInventoryDataSet FindWarehouseInventory(int intWarehouseID)
        {
            try
            {
                aFindWarehouseInventoryDataSet = new FindWarehouseInventoryDataSet();
                aFindWarehouseInventoryTableAdapter = new FindWarehouseInventoryDataSetTableAdapters.FindWarehouseInventoryTableAdapter();
                aFindWarehouseInventoryTableAdapter.Fill(aFindWarehouseInventoryDataSet.FindWarehouseInventory, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Find Warehouse Inventory " + Ex.Message);
            }

            return aFindWarehouseInventoryDataSet;
        }
        public FindCompleteInventoryDataSet FindCompleteInventory()
        {
            try
            {
                aFindCompleteInventoryDataSet = new FindCompleteInventoryDataSet();
                aFindCompleteInventoryTableAdapter = new FindCompleteInventoryDataSetTableAdapters.FindCompleteInventoryTableAdapter();
                aFindCompleteInventoryTableAdapter.Fill(aFindCompleteInventoryDataSet.FindCompleteInventory);
            }
            catch (Exception EX)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Find Complete Inventory " + EX.Message);
            }

            return aFindCompleteInventoryDataSet;
        }
        public bool UpdateInventoryPart(int intTransactionID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateInventoryPartDataTableAdapter = new UpdateInventoryPartDataTableAdapters.QueriesTableAdapter();
                aUpdateInventoryPartDataTableAdapter.UpdateInventoryPart(intTransactionID, intQuantity);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Update Inventory Part " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertInventoryPart(int intPartID, int intQuantity, int intWarehouseID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertInventoryPartTableAdapter = new InsertInventoryPartDataTableAdapters.QueriesTableAdapter();
                aInsertInventoryPartTableAdapter.InsertInventoryPart(intPartID, intQuantity, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Insert Inventory Part " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public InventoryDataSet GetInventoryInfo()
        {
            try
            {
                aInventoryDataSet = new InventoryDataSet();
                aInventoryTableAdapter = new InventoryDataSetTableAdapters.inventoryTableAdapter();
                aInventoryTableAdapter.Fill(aInventoryDataSet.inventory);
             }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // get Inventory Info " + Ex.Message);
            }

            return aInventoryDataSet;
        }
        public void UpdateInventoryDB(InventoryDataSet aInventoryDataSet)
        {
            try
            {
                aInventoryTableAdapter = new InventoryDataSetTableAdapters.inventoryTableAdapter();
                aInventoryTableAdapter.Update(aInventoryDataSet.inventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Class // Update Inventory DB " + Ex.Message);
            }
        }
    }
}
