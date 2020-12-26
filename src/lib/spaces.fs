\ lib/spaces.fs

\ This file is part of Sin Forth.

\ This file adds `spaces` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260226.
\ See change log at the end of the file.

\ ==============================================================

require b-l.fs   \ `bl`
require emits.fs \ `emits`
require swap.fs  \ `swap`

get-order get-current

target-definitions

: spaces ( n -- )
  bl swap emits ;

  \ doc{
  \
  \ spaces ( n -- )
  \
  \ If _n_ is greater than zero, display _n_ spaces.
  \
  \ See also: `space`, `bl`, `emits`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
