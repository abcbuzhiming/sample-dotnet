# Winform界面显示音频频谱
用Winform播放音频，并显示频谱界面
google搜索关键字: 
* c# spectrum analyzer
* Peak Meter

## 参考
[快速傅里叶变换（FFT）的C#实现及详细注释](https://blog.csdn.net/u011583927/article/details/46991619) 
本文讲述将音频数据转化为波形或频谱数据的转换原理

[Audio playback and spectrum analysis libarary for C# [closed]](https://stackoverflow.com/questions/12616109/audio-playback-and-spectrum-analysis-libarary-for-c-sharp)
本文提供了3种音频播放方案

[How to graph an adudio peak meter](https://social.msdn.microsoft.com/Forums/vstudio/en-US/54aa19e7-a91e-4619-b684-10b26c2f3970/how-to-graph-an-adudio-peak-meter?forum=vbgeneral)
本文提供了3个源码方案播放音频并展示频谱图，甚至有使用direct3d的方案

[C# BASS音频库 + 频谱基本用法](https://www.cnblogs.com/mumu9008/p/12469384.html)
提供WindowsFormsApp3的源码，使用BASS音频播放库和PeakMeterCtrl这个音频播放控件


## C# 音频播放方案
NAudio : http://naudio.codeplex.com/ (开源)
Bass and Bass.Net: http://www.un4seen.com/ (不开源，非商业使用免费)
Fmod Ex: https://www.fmod.com/ (不开源，非商业使用免费)


## 代码范例
[Multimedia PeakMeter Control](https://www.codeproject.com/Articles/1645/Multimedia-PeakMeter-Control)
[Multimedia PeakMeter Control](https://www.codeproject.com/Articles/26357/Multimedia-PeakMeter-Control-2)
[PeakMeter Control](http://www.ernzo.com/blogs/peakmeter-control)		提供PeakMeter控件的C#和MFC版本
[Play Wave file with DirectSound and display its spectrum in real time](https://www.codeproject.com/Articles/29366/Play-Wave-file-with-DirectSound-and-display-its-sp)

