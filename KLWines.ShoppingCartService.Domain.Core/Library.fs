namespace KLWines.ShoppingCartService.Domain.Core


// Value Objects
type ProductSku = Uint
type ProductName = string
type ProductQuantity = Uint

type Product(sku:ProductSku, name:ProductName) =
    member this.Sku = sku
    member this.Name = name

type BasketItem(product: Product, qty:ProductQuantity) =
    member this.Product = product
    member this.Qty = qty



//events
type BasketItemAdded(product: Product, qty:ProductQuantity) =
    member this.Product = Product
    member this.Qty = qty

type BasketItemRemoved(product: Product) =
    member this.Product = product

type BasketItemQtyAdjusted(product:Product, qty: ProductQuantity) =
    member this.Product = product
    member this.Qty = qty