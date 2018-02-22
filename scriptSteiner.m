%% Árboles rectilíneos de Steiner
%
% Este script muestra el uso de las funciones inicializaSteiner,
% graficaSteiner, y costoSteiner.
%
% Manuel Valenzuela
% 29 octubre 2014

%% Datos
% Coordenadas de los datos originales
C = [0 6;0.5 0;2 5;4 8;2 3;1 6;2 9;4 0;4 15];

% Inicializa Steiner obtiene los datos de todos los nodos y aristas
% posibles.
[xC,yC,P,ind,A,T] = inicializaSteiner(C);

%% Gráfica de los nodos

clf
% Se inicializan datos de gráfica
graficaSteiner('i',xC,yC,P,ind,A,T)
% Se grafican sólo los nodos originales
graficaSteiner('ng')
pause
% Se grafican los nodos originales y los nodos de Steiner
graficaSteiner('n')
pause

%% Gráfica de todas las aristas posibles

clf
% Se grafican todas las aristas
graficaSteiner('a')
pause
%% Gráfica de un árbol de Steiner

clf
% Grafo que se desea graficar
G = [4 8 10 17 20 22 27 37 41 42 43 44 45 47 48 57 58];
% Se inicializan datos para calcular el costo
costoSteiner(A,P,ind)
% Se calculan los costos del grafo G
[costoTotal,conectividad] = costoSteiner(G)
% Se grafica el grafo G
graficaSteiner('g',G)
title(sprintf('costoTotal=%f conectividad=%f',costoTotal,conectividad))

%% Costos de un árbol de Steiner

% Se inicializan datos para calcular el costo
costoSteiner(A,P,ind)
% Se calculan los costos del grafo G
[costoTotal,conectividad] = costoSteiner(G)

