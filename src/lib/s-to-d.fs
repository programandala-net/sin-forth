\ lib/s-to-d.fs

\ This file is part of Sin Forth.

\ This file adds `s>d` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require dup.fs       \ `dup`
require zero-less.fs \ `0<`

get-order get-current

target-definitions

: s>d ( n -- d )
  dup 0< ;

  \ doc{
  \
  \ s>d ( n -- d ) "s-to-d"
  \
  \ Sign extend a single number _n_ to form a double number _d_.
  \
  \ See also: `d>s`, `u>ud`.
  \
  \ }doc

set-current set-order
