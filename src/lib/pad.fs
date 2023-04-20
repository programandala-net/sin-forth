\ lib/pad.fs

\ This file is part of Sin Forth.

\ This file adds `pad` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261532.
\ See change log at the end of the file.

\ ==============================================================

require here.fs       \ `here`
require plus.fs       \ `+`
require slash-hold.fs \ `/hold`

get-order get-current

target-definitions

: pad ( -- ca )
  here /hold + ;

  \ doc{
  \
  \ pad ( -- ca )
  \
  \ _ca_ is the address of a transient region that can be used to
  \ hold data for intermediate processing. It's a fixed offset
  \ (`/hold` bytes) above `here`.
  \
  \ ``pad`` is  specifically intended as  a programmer
  \ convenience. No standard words use it.
  \
  \ See also: `/pad`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
