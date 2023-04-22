\ lib/c-r.fs

\ This file is part of Sin Forth.

\ This file adds `cr` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require emit.fs    \ `emit`
require literal.fs \ `literal`

get-order get-current

target-definitions

: cr ( -- )
  13 literal emit ;

  \ doc{
  \
  \ cr ( -- ) "c-r"
  \
  \ Transmit a carriage return to the selected output device.
  \
  \ // XXX TODO
  \ // ``cr`` is a deferred word (see `defer`) whose default action
  \ // is `(cr`.
  \
  \ See also: `emit`.
  \
  \ }doc

set-current set-order
