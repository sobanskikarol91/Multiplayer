using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class ByteBuffer : IDisposable
{
    private List<byte> buff = new List<byte>();
    private byte[] readBuff;
    private bool isBuffUpdated = false;
    private bool disposedValue = false;

    public int ReadPos { get; private set; } = 0;
    public int Count => buff.Count;
    public int Length => Count - ReadPos;
    public bool IsEmpty => Count == 0;

    public void Clear()
    {
        buff.Clear();
        ReadPos = 0;
    }

    public byte[] ToArray() => buff.ToArray();

    public void WriteByte(byte input)
    {
        buff.Add(input);
        BuffHasBeenUpdated();
    }
    public void WriteBytes(byte[] input)
    {
        buff.AddRange(input);
        BuffHasBeenUpdated();
    }
    public void WriteShort(short input)
    {
        buff.AddRange(BitConverter.GetBytes(input));
        BuffHasBeenUpdated();
    }
    public void WriteInteger(int input)
    {
        buff.AddRange(BitConverter.GetBytes(input));
        BuffHasBeenUpdated();
    }
    public void WriteLong(long input)
    {
        buff.AddRange(BitConverter.GetBytes(input));
        BuffHasBeenUpdated();
    }
    public void WriteFloat(float input)
    {
        buff.AddRange(BitConverter.GetBytes(input));
        BuffHasBeenUpdated();
    }
    public void WriteBool(bool input)
    {
        buff.AddRange(BitConverter.GetBytes(input));
        BuffHasBeenUpdated();
    }
    public void WriteString(string input)
    {
        buff.AddRange(BitConverter.GetBytes(input.Length));
        buff.AddRange(Encoding.ASCII.GetBytes(input));
        BuffHasBeenUpdated();
    }

    public byte ReadByte(bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            byte value = readBuff[ReadPos];

            if (peek & buff.Count > ReadPos)
                ReadPos++;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Byte");
        }
    }
    public byte[] ReadBytes(int length, bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            byte[] value = buff.GetRange(ReadPos, length).ToArray();

            if (peek)
                ReadPos += length;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Byte[]");
        }
    }
    public short ReadShort(bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            short value = BitConverter.ToInt16(readBuff, ReadPos);

            if (peek & buff.Count > ReadPos)
                ReadPos += 2;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Short");
        }
    }
    public int ReadInteger(bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            int value = BitConverter.ToInt32(readBuff, ReadPos);

            if (peek & buff.Count > ReadPos)
                ReadPos += 4;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Integer");
        }
    }
    public long WriteLong(bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            long value = BitConverter.ToInt64(readBuff, ReadPos);

            if (peek & buff.Count > ReadPos)
                ReadPos += 8;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Long");
        }
    }
    public float WriteFloat(bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            float value = BitConverter.ToSingle(readBuff, ReadPos);

            if (peek & buff.Count > ReadPos)
                ReadPos += 4;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Long");
        }
    }
    public bool ReadBool(bool peek = true)
    {
        if (buff.Count > ReadPos)
        {
            CheckBufferUpdate();

            bool value = BitConverter.ToBoolean(readBuff, ReadPos);

            if (peek & buff.Count > ReadPos)
                ReadPos++;

            return value;
        }
        else
        {
            throw new Exception("You are trying yo read out a Long");
        }
    }
    public string ReadString(bool peek = true)
    {
        try
        {
            int length = ReadInteger(true);
            if (isBuffUpdated)
            {
                readBuff = buff.ToArray();
                isBuffUpdated = false;
            }

            string value = Encoding.ASCII.GetString(readBuff, ReadPos, length);

            if (peek & buff.Count > ReadPos)
            {
                if (value.Length > 0)
                    ReadPos += length;
            }

            return value;
        }
        catch (Exception)
        {

            throw new Exception("You are trying yo read out a Long");
        }
    }

    private void CheckBufferUpdate()
    {
        if (isBuffUpdated)
        {
            readBuff = buff.ToArray();
            isBuffUpdated = false;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            disposedValue = true;
        }
        else
            Clear();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void BuffHasBeenUpdated() => isBuffUpdated = true;
}