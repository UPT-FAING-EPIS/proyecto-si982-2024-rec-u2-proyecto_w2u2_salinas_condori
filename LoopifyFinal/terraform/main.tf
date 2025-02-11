terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.16"
    }
  }
}

provider "azurerm" {
  features {}

  subscription_id = "ff6d9c66-512b-457e-a72f-2bcdf38cce4c"
}

# Grupo de recursos
resource "azurerm_resource_group" "web_group" {
  name     = "grupo-web"
  location = "Central US"
}

# Plan de servicio con nivel gratuito
resource "azurerm_service_plan" "web_plan" {
  name = "loopify-web-plan"
  location            = azurerm_resource_group.web_group.location
  resource_group_name = azurerm_resource_group.web_group.name
  os_type             = "Windows"
  sku_name            = "F1"  # Nivel gratuito
}

# App Service en Windows
resource "azurerm_windows_web_app" "web_app" {
  name = "mi-web-unique-12345"
  location            = azurerm_resource_group.web_group.location
  resource_group_name = azurerm_resource_group.web_group.name
  service_plan_id     = azurerm_service_plan.web_plan.id
  https_only          = true

  site_config {
    always_on           = false
    ftps_state          = "Disabled"
    http2_enabled       = true
    minimum_tls_version = "1.2"
  }
}

# Cuenta de almacenamiento para imágenes de productos
resource "azurerm_storage_account" "web_storage" {
  name = "loopifystorage12345"
  resource_group_name      = azurerm_resource_group.web_group.name
  location                 = azurerm_resource_group.web_group.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "product_images" {
  name                  = "product-images"
  storage_account_id = azurerm_storage_account.web_storage.id
  container_access_type = "private"
}

# Base de datos PostgreSQL optimizada para reducir costos
resource "azurerm_postgresql_flexible_server" "db" {
  depends_on = [azurerm_resource_group.web_group]
  version = "12"  # Se agrega la versión requerida
  administrator_login = "adminuser"
  administrator_password = "SecurePassword123!"
  name                = "mi-base-de-datos"
  resource_group_name = azurerm_resource_group.web_group.name
  location            = azurerm_resource_group.web_group.location
  sku_name = "B_Standard_B1ms"  # Plan más barato
  storage_mb = 32768  # 20GB para reducir costos
}

# Se elimina el API Gateway para reducir costos
