
namespace TestParser.Constants
{
    public static class Constants
    {
        public const string Item =
            "iva-item-root-Nj_hb photo-slider-slider-_PvpN iva-item-list-H_dpX iva-item-redesign-nV4C4 iva-item-responsive-gIKjW items-item-My3ih items-listItem-Gd1jN js-catalog-item-enum";

        //<h3 itemprop="name" class="title-root-j7cja iva-item-title-_qCwt title-listRedesign-XHq38 title-root_maxHeight-SXHes text-text-LurtD text-size-s-BxGpL text-bold-SinUO">Apple MacBook Pro 15 2018 i7 2.6GHz/512 gb SSD</h3>
        public const string ItemTitle = "title-root-j7cja iva-item-title-_qCwt title-listRedesign-XHq38 title-root_maxHeight-SXHes text-text-LurtD text-size-s-BxGpL text-bold-SinUO";

        //<span class="price-text-E1Y7h text-text-LurtD text-size-s-BxGpL">57&nbsp;000<!-- -->&nbsp;<span class="price-currency-_B87m">₽</span></span>
        public const string ItemPrice = "price-text-E1Y7h text-text-LurtD text-size-s-BxGpL";

        //<span class="geo-address-QTv9k text-text-LurtD text-size-s-BxGpL"><span>Астраханская область, Астрахань</span></span>
        public const string ItemCity = "geo-address-QTv9k text-text-LurtD text-size-s-BxGpL";

        //<a href="/astrahan/noutbuki/apple_macbook_pro_15_2018_i7_2.6ghz512_gb_ssd_2259057833?slocation=621540" target="_blank" rel="noopener" title="Apple MacBook Pro 15 2018 i7 2.6GHz/512 gb SSD в Астрахани" itemprop="url" data-marker="item-title" class="link-link-MbQDP link-design-default-_nSbv title-root-j7cja iva-item-title-_qCwt title-listRedesign-XHq38 title-root_maxHeight-SXHes"><h3 itemprop="name" class="title-root-j7cja iva-item-title-_qCwt title-listRedesign-XHq38 title-root_maxHeight-SXHes text-text-LurtD text-size-s-BxGpL text-bold-SinUO">Apple MacBook Pro 15 2018 i7 2.6GHz/512 gb SSD</h3></a>
        public const string ItemRef = "href";

        //<img class="photo-slider-image-_Dc4I" itemprop="image" importance="high" elementtiming="bx.gallery.first-item" alt="Apple MacBook Pro 15 2018 i7 2.6GHz/512 gb SSD" src="https://06.img.avito.st/image/1/d5N_RbaB23oJ4Cl8HVw38ZLm33zd4Nt8uoXffAngKXzJ4td-yeTbPg" srcset="" sizes="
        //(min-width: 1334px) 236px,
        //208px
        //">
        public const string ItemPhotoRef = "photo-slider-image-_Dc4I";
    }
}
