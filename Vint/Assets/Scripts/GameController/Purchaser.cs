using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//usamos la libreria de IAP
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour,IStoreListener {

	private static IStoreController _controller;
	private static IExtensionProvider _extension;

	//id de los productos a comprar, en este caso solo usaremos productos "consumable"
	public static string oneCoinID = "onecoin";   
	public static string  oneHundredCoinsID = "onehundredcoins";
	public static string infinityCoinsID =  "infinitycoins"; 

	void Start()
	{
		//Si no encontramos la referencia del _controller
		if (_controller == null)
		{
			InitializePurchasing();
		}
	}

	public void InitializePurchasing() 
	{
		//Si nos conectamos al purchasing
		if (IsInitialized())
		{
			return;
		}

		// creamos un builder para pasar los productos a unity purchasing
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		builder.AddProduct(oneCoinID, ProductType.Consumable);
		builder.AddProduct (oneHundredCoinsID, ProductType.Consumable);
		builder.AddProduct (infinityCoinsID, ProductType.Consumable);
	
		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Inicializamos si se seteó los elementos de compra
		return _controller != null && _extension != null;
	}
	//Función para comprar el producto
	public void BuyProductID(string productId)
	{
		
		if (IsInitialized())
		{
			
			Product product = _controller.products.WithID(productId);

			if (product != null && product.availableToPurchase)
			{
				_controller.InitiatePurchase(product);
				Debug.Log ("Compraste el producto " + productId);

			}else
			{
				Debug.Log("Hubo un error al realizar la compra de "+ productId);
			}
		}else
		{
			Debug.Log("No se a inicializado correctamente el sistema de compra");
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		_controller = controller;
		_extension = extensions;
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed:" + error);
	}

	public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs e)
	{
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed (Product product, PurchaseFailureReason reason)
	{
		
	}
}
