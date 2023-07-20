﻿using AluguelRV.Api.Dapper.Data;

namespace AluguelRV.Api;

public static class Person
{
    public static async Task<IResult> GetAll(PersonData personData)
    {
        var data = await personData.GetAll();

        return Api.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetById(PersonData personData, int id)
    {
        var data = await personData.GetById(id);

        return Api.CheckNullAndRespond(data);
    }
}