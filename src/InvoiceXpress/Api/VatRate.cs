﻿using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<VatRate>> VatRateCreateAsync( VatRate rate )
    {
        if ( rate.Id.HasValue == true )
            throw new ArgumentException( ".Id property is prohibited when creating a VAT rate", nameof( rate ) );

        var payload = new
        {
            tax = new VatRateEx()
            {
                Code = rate.Code,
                Value = rate.Value,
                Region = rate.Region,
                IsDefaultRate = rate.IsDefaultRate,
            },
        };

        var req = new RestRequest( "/taxes.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PostAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<VatRatePayload>()!;
            return Ok( resp.StatusCode, body.VatRate );
        }

        return Error<VatRate>( resp );
    }


    /// <summary />
    public async Task<ApiResult<VatRate>> VatRateGetAsync( int rateId )
    {
        var req = new RestRequest( $"/taxes/{ rateId }.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<VatRatePayload>()!;
            return Ok( resp.StatusCode, body.VatRate );
        }

        return Error<VatRate>( resp );
    }


    /// <summary />
    public async Task<ApiResult> VatRateUpdateAsync( VatRate rate )
    {
        if ( rate.Id.HasValue == false )
            throw new ArgumentException( ".Id property is required when updating a VAT rate", nameof( rate ) );

        var req = new RestRequest( $"/taxes/{ rate.Id.Value }.json" )
            .AddJsonBody( new VatRatePayload() { VatRate = rate } );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult> VatRateDeleteAsync( int rateId )
    {
        var req = new RestRequest( $"/taxes/{ rateId }.json" );

        var resp = await _rest.DeleteAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<List<VatRate>>> VatRateListAsync()
    {
        var req = new RestRequest( "/taxes.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<VatRateListPayload>()!;
            return Ok( resp.StatusCode, body.VatRates );
        }

        return Error<List<VatRate>>( resp );
    }
}
