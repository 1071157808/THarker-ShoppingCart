namespace KLWines.ShoppingCartService.Domain.Core



    // Value Objects
    type ProductSku = int
    type ProductName = string
    type ProductQuantity = int

    type Product(sku:ProductSku, name:ProductName) =
        member this.Sku = sku
        member this.Name = name

    type BasketItem(product: Product, qty:ProductQuantity) =
        member this.Product = product
        member this.Qty = qty



//events
    type IEvent =
        interface
        end
    type BasketItemAdded(product: Product, qty:ProductQuantity) =
        interface IEvent
        member this.Product = Product
        member this.Qty = qty

    type BasketItemRemoved(product: Product) =
        interface IEvent
        member this.Product = product

    type BasketItemQtyAdjusted(product:Product, qty: ProductQuantity) =
        interface IEvent
        member this.Product = product
        member this.Qty = qty


    //exceptions
    type ProductDoesntExistInShoppingCart(sku:ProductSku) =
        member this.Sku = sku;
    exception ProductDoesntExistInShoppingCartException of ProductDoesntExistInShoppingCart

    type ProductAlreadyExistsInShoppingCart(sku:ProductSku) = 
        member this.Sku = sku;
    exception ProductAlreadyExistsInShoppingCartException of ProductAlreadyExistsInShoppingCart
    