# DB Backup Yükleme ve Konfigürasyon

Bu proje, `UI` katmanı altında bulunan **dbfirst.bak** dosyası ile birlikte gelmektedir. Bu dosya bir **SQL Server veritabanı yedeğidir** ve projeyi çalıştırabilmek için yüklenmesi gerekmektedir.

## 1. Veritabanı Yedeğinin MSSQL'e Yüklenmesi

1. **SQL Server Management Studio (SSMS)** uygulamasını açın.
2. **`Veritabanları (Databases)`** üzerine sağ tıklayın ve **`Veritabanı Geri Yükle (Restore Database)`** seçeneğini seçin.
3. **Cihaz (Device)** seçeneğini işaretleyin ve **Gözat (Browse)** butonuna tıklayın.
4. **UI/dbfirst.bak** dosyasının yolunu seçin ve onaylayın.
5. Hedef veritabanı adı olarak `DBFirstApp` veya istediğiniz herhangi bir isim belirleyin.
6. İşlemi tamamlamak için **Tamam (OK)** butonuna basın.

> **Not:** Geri yükleme işleminden sonra veritabanınız kullanılabilir hale gelecektir.

---

## 2. Connection String Düzenlemesi

Veritabanı yüklendikten sonra, proje `UI` katmanı altındaki **appsettings.json** dosyasında yer alan connection string'i güncellemeniz gerekmektedir.

### Adımlar:
1. **UI/appsettings.json** dosyasını açın.
2. `ConnectionStrings` alanını bulun:
   ```json
   "ConnectionStrings": {
     "Default": "Server=.;Database=DBFirstApp;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
