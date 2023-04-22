\ lib/defer.fs

\ This file is part of Sin Forth.

\ This file adds `defer` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

compiler-definitions

: defer ( "name" -- )
  creator , 0 jp,
  does> ( dfa ) do-call ;

set-current set-order
