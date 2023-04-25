\ lib/c-r.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require emit.fs    \ `emit`
require literal.fs \ `literal`

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
