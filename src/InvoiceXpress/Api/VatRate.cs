﻿using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary>
    /// Creates a VAT rate.
    /// </summary>
    /// <param name="rate">VAT rate, with a null .Id value.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// Result of execution. If the operation completes successfully, the newly
    /// created VAT rate is returned.
    /// </returns>
    public async Task<ApiResult<VatRate>> VatRateCreateAsync( VatRate rate,
        CancellationToken cancellationToken = default( CancellationToken ) )
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

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<VatRatePayload>()!;
            return Ok( resp.StatusCode, body.VatRate );
        }

        return Error<VatRate>( resp );
    }


    /// <summary>
    /// Retrieves a VAT rate.
    /// </summary>
    /// <param name="rateId">VAT rate id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// Result of execution. If the operation completes successfully, the VAT
    /// rate is returned.
    /// </returns>
    public async Task<ApiResult<VatRate>> VatRateGetAsync( int rateId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/taxes/{ rateId }.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<VatRatePayload>()!;
            return Ok( resp.StatusCode, body.VatRate );
        }

        return Error<VatRate>( resp );
    }


    /// <summary>
    /// Updates a VAT rate.
    /// </summary>
    /// <param name="rate">VAT rate.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// Result of execution.
    /// </returns>
    public async Task<ApiResult> VatRateUpdateAsync( VatRate rate,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        if ( rate.Id.HasValue == false )
            throw new ArgumentException( ".Id property is required when updating a VAT rate", nameof( rate ) );

        var req = new RestRequest( $"/taxes/{ rate.Id.Value }.json" )
            .AddJsonBody( new VatRatePayload() { VatRate = rate } );

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary>
    /// Deletes a VAT rate.
    /// </summary>
    /// <param name="rateId">VAT rate id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// Result of execution.
    /// </returns>
    public async Task<ApiResult> VatRateDeleteAsync( int rateId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/taxes/{ rateId }.json", Method.Delete );

        var resp = await _rest.ExecuteAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary>
    /// Lists all defined VAT rates.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// Result of execution. If the operation completes successfully, the full
    /// list of VAT rates is returned.
    /// </returns>
    public async Task<ApiResult<List<VatRate>>> VatRateListAsync( CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/taxes.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<VatRateListPayload>()!;
            return Ok( resp.StatusCode, body.VatRates );
        }

        return Error<List<VatRate>>( resp );
    }
}
